#!/usr/bin/env bash

set -eu
set -o pipefail

dotnet tool restore
dotnet paket restore
dotnet fake "$@"
