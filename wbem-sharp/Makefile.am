SUBDIRS = src doc

DIST_SUBDIRS = $(SUBDIRS)

EXTRA_DIST =

export PKG_CONFIG_PATH := $(PKG_CONFIG_PATH)

clean-local:
	rm -rf $(COMMON_CLEAN_FILES)

distclean-local:
	rm -rf $(COMMON_DISTCLEAN_FILES)

maintainer-clean-local:
	rm -rf $(COMMON_MAINTAINER_CLEAN_FILES)
	rm -f configure $(PACKAGE)-*.tar.gz config.cache
	rm -f aclocal.m4 conf*.sh configure.lineno config.log
	rm -f config.guess config.sub config.status config.h.in
	rm -f ltmain.sh libtool
	rm -f install-sh install-sh.lnk INSTALL INSTALL.lnk
	rm -f missing missing.lnk mkinstalldirs mkinstalldir.lnk
	rm -rf autom4te.cache

.PHONY: test
test: install
	$(MAKE) -C test test
		
test-clean:
	$(MAKE) -C test clean
		
.PHONY: doc doc-clean
doc:
	$(MAKE) -C doc doc

doc-nodeps:
	$(MAKE) -C doc all-nodeps

doc-clean:
	$(MAKE) -C doc clean

.PHONY: package package-sdk package-clean

package:
	$(MAKE) -C package all

package-sdk:
	$(MAKE) -C package sdk

package-clean:
	$(MAKE) -C package clean

