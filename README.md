# Hashx

![Build](https://github.com/ibbgomes/hashx/workflows/Build/badge.svg)

A cross-platform, command-line interface, hashing utility. 🔐

## Usage

```txt
Description:
  A cross-platform, command-line interface, hashing utility

Usage:
  hashx [<input>] [options]

Arguments:
  <input>  Path to the input file. If none, reads from stdin

Options:
  -a, --algorithms <list> (REQUIRED)  Set one or more space-separated algorithms
  -c, --compare <hash>                Compare results against an expected hash
  --json                              Output results in JSON
  -?, -h, --help                      Show help and usage information
  --version                           Show version information

Algorithms:
  crc32, crc64, md5, sha1, sha256, sha3_256, sha3_384, sha3_512, sha384, sha512, xxh128, xxh3, xxh32, xxh64

Exit Codes:
  0  Success
  1  Processing error
  2  Hash mismatch
```
