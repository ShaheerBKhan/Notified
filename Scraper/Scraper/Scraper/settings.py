# Scrapy settings for Scraper project
#
# For simplicity, this file contains only settings considered important or
# commonly used. You can find more settings consulting the documentation:
#
#     https://docs.scrapy.org/en/latest/topics/settings.html
#     https://docs.scrapy.org/en/latest/topics/downloader-middleware.html
#     https://docs.scrapy.org/en/latest/topics/spider-middleware.html

BOT_NAME = "Scraper"

SPIDER_MODULES = ["Scraper.spiders"]
NEWSPIDER_MODULE = "Scraper.spiders"

# Robots.txt Rule:
ROBOTSTXT_OBEY = False

# Configure Item Pipeline:
# See https://docs.scrapy.org/en/latest/topics/item-pipeline.html
ITEM_PIPELINES = {
    "Scraper.pipelines.JobPostingIdsPipeline": 300,
}

# Configure Retry Settings:
RETRY_ENABLED = True
RETRY_TIMES = 2
RETRY_HTTP_CODES = [400, 402, 403, 404, 408, 500, 502, 503, 504] 
RETRY_PRIORITY_ADJUST = -1
RETRY_BACKOFF_BASE = 2
RETRY_BACKOFF_MULTIPLIER = 1.5

# Set Settings for Future-Proofing:
REQUEST_FINGERPRINTER_IMPLEMENTATION = "2.7"
TWISTED_REACTOR = "twisted.internet.asyncioreactor.AsyncioSelectorReactor"
FEED_EXPORT_ENCODING = "utf-8"
