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
  <input>  Path to the input file

Options:
  -?, -h, --help               Show help and usage information
  --version                    Show version information
  -a, --algorithms (REQUIRED)  Set the hashing algorithms
  -c, --compare                Compare results against a checksum
  --json                       Output results in JSON

Algorithms:
  crc32, crc64, md5, sha1, sha256, sha384, sha512, xxh128, xxh3, xxh32, xxh64

Exit Codes:
  0  Success
  1  Processing error
  2  Checksum mismatch
```
