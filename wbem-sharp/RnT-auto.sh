#!/bin/bash

cd $(dirname $0)
PREFIX=$(pwd)
./autogen.sh --prefix=$PREFIX
