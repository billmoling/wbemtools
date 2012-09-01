# handle Mono secondary dependencies
export MONO_PATH := $(MONO_PATH)
DIST_SUBDIRS = 

MONO_MAN_DLL = $(MONO_MAN_BIN)/Mono.Management.dll
MONO_MAN_XML = $(MONO_MAN_DOC)/Mono.Management.xml
MONO_MAN_MONODOC = $(MONO_MAN_DOC)/MonoDoc


EXTRA_DIST = *

CUR_DIR := $(shell pwd)

all: 

$(MONO_MAN_DLL):
	$(MAKE) -C ../../src/Mono.Management all

doc: $(MONO_MAN_DLL)
	$(MONODOCER) -assembly:$(MONO_MAN_DLL) -path:$(MONO_MAN_MONODOC) -importslashdoc:$(MONO_MAN_XML)

clean-local:
	rm -rf $(COMMON_CLEAN_FILES)

distclean-local:
	rm -rf $(COMMON_DISTCLEAN_FILES)

maintainer-clean-local:
	rm -rf $(COMMON_MAINTAINER_CLEAN_FILES)

