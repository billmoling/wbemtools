# handle Mono secondary dependencies
export MONO_PATH := $(MONO_PATH)

#Client_CSFILES = $(srcdir)/AssemblyInfo.cs $(srcdir)/SimpleWebService.cs $(srcdir)/main.cs $(srcdir)/Arguments.cs $(srcdir)/StopWatch.cs
CSFILES = $(srcdir)/*.cs $(srcdir)/Collections/*.cs $(srcdir)/BaseDataTypes/*.cs $(srcdir)/OpSettings/*.cs $(srcdir)/Batch/*.cs $(srcdir)/CimDataTypes/*.cs $(srcdir)/CimXml/*.cs $(srcdir)/Net/*.cs $(srcdir)/Properties/*.cs
CSFILES_CSC := $(subst /,$(SEP),$(CSFILES))
INCLUDES =
RESOURCES =
WBEM_DLL = wbem-sharp.dll
MONO_MAN_XML = $(MONO_MAN_DOC)/wbem-sharp.xml
FLAGS = $(CSC_LIBFLAG)
#Client_LIBS = System.dll System.Web.Services.dll $(SYSTEM_XML)
LIBS = 
LIBPATH =

EXTRA_DIST = $(CSFILES) wbem-sharp.csproj

CUR_DIR := $(shell pwd)

all: $(WBEM_DLL)

#$(srcdir)/SimpleWebService.cs: $(srcdir)/../SimpleService/SimpleService.wsdl
#	wsdl -nologo -out:SimpleWebService.cs $(srcdir)/../SimpleService/SimpleService.wsdl

#	wsdl -nologo -out:ClientWebService.cs $(srcdir)/../WebService/ClientWebService.wsdl
#	We used to have to do this because of the way the wdsl was being generated
#   But it all appears fine after switching to [SoapDocumentMethod]
#	cat ClientWebService.cs | sed 's/Client1/Client/' | sed 's/ClientUser1/ClientUser/' | sed 's/DiskSpace1/DiskSpace/' > newsource.cs
#	mv newsource.cs ClientWebService.cs
#$(CSC) /out:$@ $(CSCFLAGS) $(FLAGS) $(LIBS:%=/r:%) $(LIBPATH:%=/lib:%) $(CSFILES_CSC) /doc:SimpleClient.doc.xml
$(WBEM_DLL): $(CSFILES) $(RESOURCES)
	$(CSC) -out:$(WBEM_DLL) $(CSCFLAGS) $(FLAGS) $(CSFILES_CSC) -doc:$(MONO_MAN_XML)

doc: $(WBEM_DLL)
	$(MONODOCER) -assembly:$(WBEM_DLL) -path:$(MONO_MAN_MONODOC) -importslashdoc:$(MONO_MAN_XML)

install-exec-local: $(WBEM_DLL)
	$(GACUTIL) -i $(WBEM_DLL) -root $(DESTDIR)$(libdir) -check_refs

uninstall-local:
	$(GACUTIL) -us $(WBEM_DLL)

#install-exec-local: $(WBEM_DLL)
#	$(mkinstalldirs) $(DESTDIR)$(bindir)
#	$(INSTALL_PROGRAM) $(WBEM_DLL) $(DEBUG_FILES) $(DESTDIR)$(bindir)

#uninstall-local:
#	cd $(DESTDIR)$(bindir); rm -f $(WBEM_DLL) $(DEBUG_FILES)

CLEAN_FILES = $(WBEM_DLL) $(MONO_MAN_XML)

clean-local:
	rm -rf $(CLEAN_FILES) $(COMMON_CLEAN_FILES)
    
distclean-local:
	rm -rf $(COMMON_DISTCLEAN_FILES)

maintainer-clean-local:
	rm -rf $(COMMON_MAINTAINER_CLEAN_FILES)

