# Define your item pipelines here
#
# Don't forget to add your pipeline to the ITEM_PIPELINES setting
# See: https://docs.scrapy.org/en/latest/topics/item-pipeline.html


class JobPostingIdsPipeline:
    def process_item(self, item, spider):
        return item
    
    def open_spider(self, spider):
        company_id = spider.company_id
        # TODO: set company_job_posting_ids