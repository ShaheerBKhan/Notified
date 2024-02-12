#!/bin/bash

# Define the list of spiders
spiders=("Meta" "Amazon" "Apple" "Netflix" "Google" "Microsoft")

# Function to run spider in background
run_spider() {
    scrapy crawl $1 -o Output/$1.json
}

# Run each spider in parallel
for spider in "${spiders[@]}"
do
    run_spider "$spider" &
done

# Wait for all background processes to finish
wait

echo "All spiders have finished crawling."