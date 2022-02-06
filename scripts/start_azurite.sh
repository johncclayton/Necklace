#!/bin/bash

SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )
cd "$SCRIPT_DIR"/.. || echo "Failed to cd to the root directory" && return

if [ ! -d Azurite ]; then
    mkdir Azurite
fi

azurite --silent --location ./Azurite