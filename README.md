# Hashx

![Build](https://github.com/ibbgomes/hashx/workflows/Build/badge.svg)

A multi-platform, command line interface, checksum utility.

## Usage

```txt
Hashx:
  A multi-platform, command line interface, checksum utility

Usage:
  Hashx [options] <input>

Arguments:
  <input>    The path of the file to be handled

Options:
  -a, --algorithms <md5|sha1|sha256|sha384|sha512> (REQUIRED)    Define the hashing algorithms used to generate the checksums
  -c, --compare <compare>                                        Compare the generated checksums against the specified checksum
  --json                                                         Output the generated checksums as JSON
  --xml                                                          Output the generated checksums as XML
  --version                                                      Show version information
  -?, -h, --help                                                 Show help and usage information
```
