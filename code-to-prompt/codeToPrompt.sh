#!/bin/bash

# Check if the directory is provided
if [ -z "$1" ]; then
    echo "Usage: $0 <directory>"
    exit 1
fi

# The directory to start from
start_dir="$1"

# The output file where all contents will be saved
output_file="prompt.txt"

# Empty the output file if it already exists
> "$output_file"

# Function to process each file
process_file() {
    local file="$1"
    # Check if the file is an image and skip it if true
    case "${file##*.}" in
        jpg|jpeg|png|gif|bmp|tiff|tif|webp|svg)
            return
            ;;
    esac
    # Add the full relative path of the file at the top
    echo "FILE NAME: ${file#./}" >> "$output_file"
    echo "" >> "$output_file"
    # Add the file contents
    cat "$file" >> "$output_file"
    echo "" >> "$output_file"
    echo "" >> "$output_file"
}

# Export the function so it can be used by find
export -f process_file
export output_file

# Find all files recursively in the specified directory and process them
find "$start_dir" -type f -exec bash -c 'process_file "$0"' {} \;

# Add two extra lines at the end
echo "" >> "$output_file"
echo "" >> "$output_file"

echo "Processing complete. The contents have been saved to $output_file"
