export FrameworkPathOverride=$(shell dirname $(shell which mono))/../lib/mono/4.5/
BUILD_CMD=dotnet build --no-restore /property:GenerateFullPaths=true
VERSION=$(shell cat .version 2>/dev/null || echo 1.0.0-SNAPSHOT)

all: configure build

configure:
	dotnet restore

build:
	$(BUILD_CMD)

unittest:
	dotnet test

pack:
	dotnet pack -c Release -p:PackageVersion=$(VERSION)
