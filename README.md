# Hashx

![Build](https://github.com/ibbgomes/hashx/workflows/Build/badge.svg)

A cross-platform, command-line interface, checksum utility. 🔐

## Usage

```txt
Description:
  A cross-platform, command-line interface, checksum utility

Usage:
  Hashx <input> [options]

Arguments:
  <input>  Specify the input file path

Options:
  -?, -h, --help               Show help and usage information
  --version                    Show version information
  -a, --algorithms (REQUIRED)  Specify the hashing algorithms
  -c, --compare                Compare the results against a checksum
  --json                       Print the results in JSON format

Algorithms:
  crc32, crc64, md5, sha1, sha256, sha384, sha512, xxh128, xxh3, xxh32, xxh64

Exit Codes:
  0  Success
  1  Error during processing
  2  Checksum comparison failed
```
