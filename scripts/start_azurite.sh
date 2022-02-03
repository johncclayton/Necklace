#!/bin/bash

SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )
cd $SCRIPT_DIR/..

if [ ! -d Azurite ]; then
    mkdir Azurite
fi

azurite --silent --location ./Azurite