import json
import re

import scrapy
from Scraper.request_consts import job, job_page


class BaseSpider(scrapy.Spider):
    name = "BaseSpider"
    allowed_domains = ["www.linkedin.com"]

    request_url_template = "https://www.linkedin.com/voyager/api/voyagerJobsDashJobCards?decorationId=com.linkedin.voyager.dash.deco.jobs.search.JobSearchCardsCollectionLite-62&count={}&q=jobSearch&query=(origin:JOB_SEARCH_PAGE_JOB_FILTER,keywords:software%20engineer,selectedFilters:(company:List({}),timePostedRange:List(r{})),spellCorrectionEnabled:true)&start={}"

    count = 100
    company_id = None
    time_interval_in_seconds = 2592000
    number_of_results = None
    job_page_headers = job_page["headers"]
    job_page_cookies = job_page["cookies"]
    job_headers = job["headers"]

    company_job_posting_ids = {}

    download_delay = 1

    def start_requests(self):
        start=0
        request_url = self.request_url_template.format(self.count, self.company_id, self.time_interval_in_seconds,start)
        yield scrapy.Request(url=request_url, headers=self.job_page_headers, cookies=self.job_page_cookies, dont_filter=True, callback=self.parse_job_page_api_number_of_results)


    def parse_job_page_api_number_of_results(self, response):
        number_of_results_string = json.loads(response.body)['data']['metadata']['subtitle']['text']
        self.number_of_results = self.extract_number_of_results(number_of_results_string)

        if self.number_of_results is not None:
            for start_index in range(0, self.number_of_results+1, 100):
                request_url = self.request_url_template.format(self.count, self.company_id, self.time_interval_in_seconds, start_index)
                yield scrapy.Request(url=request_url, headers=self.job_page_headers, cookies=self.job_page_cookies, dont_filter=True, callback=self.parse_job_page_api_job_postings)
    

    def extract_number_of_results(self, number_of_results_string):
        number_of_results = None
        pattern = r'(\d+)\s+results'
        match = re.search(pattern, number_of_results_string)
        if match:
            number_of_results = int(match.group(1))
        
        return number_of_results


    def parse_job_page_api_job_postings(self, response):
        job_posting_id_string_list = json.loads(response.body)['data']['metadata']['jobCardPrefetchQueries'][0]['prefetchJobPostingCardUrns']
        for job_posting_id_string in job_posting_id_string_list:
            job_posting_id = self.extract_job_posting_id(job_posting_id_string)
            if job_posting_id and job_posting_id not in self.company_job_posting_ids:
                request_url = f"https://www.linkedin.com/voyager/api/jobs/jobPostings/{job_posting_id}"
                yield scrapy.Request(url=request_url, headers=self.job_headers, dont_filter=True, callback=self.parse_job_api)


    def extract_job_posting_id(self, job_posting_id_string):
        job_posting_id = None
        pattern = r"\((\d+),"
        match = re.search(pattern, job_posting_id_string)
        if match:
            job_posting_id = match.group(1)
        return job_posting_id
    

    def parse_job_api(self, response):
        response = json.loads(response.body)['data']
        
        title = response['title']
        application_url = response['applyMethod']['companyApplyUrl']
        if application_url is None:
            application_url = response['jobPostingUrl']
        is_remote = response['workRemoteAllowed']
        location = response['formattedLocation']
        salary = response['salaryInsights']['compensationBreakdown'][0]
        min_salary = salary['minSalary']
        max_salary = salary['maxSalary']
        description = response['description']['text']
        
        yield {
            'years_of_experience': '',
            'education': '',
            # 'title': title,
            'application_url': application_url,
            # 'is_remote': is_remote,
            # 'location': location,
            # 'min_salary': min_salary,
            # 'max_salary': max_salary,
            'description': description,
        }
