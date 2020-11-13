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
  -a, --algorithms <algorithms> (REQUIRED)    Define the hashing algorithms used to generate the checksums. Supports MD5, SHA1, SHA256, SHA384 and SHA512
  -c, --compare <compare>                     Compare the generated checksums against the specified checksum
  -o, --output <output>                       Output the generated checksums to the specified path. Supports JSON, XML and plain-text
  --version                                   Show version information
  -?, -h, --help                              Show help and usage information
```
