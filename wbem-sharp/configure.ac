AC_INIT(configure.ac)

ASSEMBLY_VERSION_LINE=`grep -i 'assembly: *AssemblyVersion' src/Properties/AssemblyInfo.cs`
ASSEMBLY_VERSION=`expr match "$ASSEMBLY_VERSION_LINE" '.*\"\(.*\)\".*'`

AC_SUBST(ASSEMBLY_VERSION)
AC_SUBST(MONO_MAN_BIN)
AC_SUBST(MONO_MAN_DOC)

AC_CANONICAL_SYSTEM
AM_INIT_AUTOMAKE(wbem-sharp,$ASSEMBLY_VERSION)
VERSION=$VERSION.`date +%Y%m%d`
AM_MAINTAINER_MODE


#
# Check for a valid operating system and C# compiler
#
case $host_os in
    linux*)
        AC_CHECK_PROG(CSC, gmcs, gmcs)
        test -z "$CSC" && AC_MSG_ERROR([no C Sharp compiler: gmcs not found in \$PATH])
        AC_CHECK_PROG(MONODOCER, monodocer, monodocer)
        test -z "$MONODOCER" && AC_MSG_ERROR([no docer: monodocer not found in \$PATH])
        AC_CHECK_PROG(GACUTIL, gacutil, gacutil)
        test -z "$GACUTIL" && AC_MSG_ERROR([no GACUTIL: gacutil not found in \$PATH])
        PKG_CONFIG_DIR='lib'
    ;;
    darwin*)
        AC_CHECK_PROG(CSC, gmcs, gmcs)
        test -z "$CSC" && AC_MSG_ERROR([no C Sharp compiler: gmcs not found in \$PATH])
        AC_CHECK_PROG(MONODOCER, monodocer, monodocer)
        test -z "$MONODOCER" && AC_MSG_ERROR([no docer: monodocer not found in \$PATH])
        AC_CHECK_PROG(GACUTIL, gacutil, gacutil)
        test -z "$GACUTIL" && AC_MSG_ERROR([no GACUTIL: gacutil not found in \$PATH])
        PKG_CONFIG_DIR='lib'
    ;;
    cygwin*)
        AC_CHECK_PROG(CSC, csc, csc)
        test -z "$CSC" && AC_CHECK_PROG(CSC, gmcs, gmcs)
        test -z "$CSC" && AC_MSG_ERROR([no C Sharp compiler: neither csc nor gmcs found in \$PATH])
        PKG_CONFIG_DIR='.'
    ;;
    *)
        AC_MSG_ERROR([Unknown host_os: $host_os])
    ;;
esac

AM_CONDITIONAL(MONO, test "$CSC" = "gmcs")
AM_CONDITIONAL(DOTNET, test "$CSC" = "csc")

#
# We add $prefix to PKG_CONFIG_PATH so pkg-config will find any other
# packages 'make install'-ed to the same prefix.
#
# The default value of $prefix is not set until later in the script.
# We set the default here, if needed.
#
test "x$prefix" = xNONE && prefix=$ac_default_prefix
test "x$exec_prefix" = xNONE && exec_prefix="${prefix}"

#
# Installation directory options.
#
# These are normally left unexpanded so users can "make install exec_prefix=/foo".
# However, we want them expanded.
#
bindir="${exec_prefix}/bin"
sbindir="${exec_prefix}/sbin"
libexecdir="${exec_prefix}/libexec"
datadir="${prefix}/share"
sysconfdir="${prefix}/etc"
sharedstatedir="${prefix}/com"
localstatedir="${prefix}/var"
libdir="${exec_prefix}/lib"
includedir="${prefix}/include"
oldincludedir="/usr/include"
infodir="${prefix}/info"
mandir="${prefix}/man"

if test -z "$PKG_CONFIG_PATH"; then
    export PKG_CONFIG_PATH="$prefix/$PKG_CONFIG_DIR/pkgconfig"
else
    export PKG_CONFIG_PATH="$prefix/$PKG_CONFIG_DIR/pkgconfig:$PKG_CONFIG_PATH"
fi
echo PKG_CONFIG_PATH=$PKG_CONFIG_PATH
AC_SUBST(PKG_CONFIG_PATH)

helpdir=\${prefix}/help
AC_SUBST(helpdir)

#
# Configure C# compiler settings
#
case $CSC in
    #
    # Mono-specific configuration
    #
    gmcs)
        CSC_EXEFLAG=/target:exe
        CSC_LIBFLAG=/target:library
        CSC_WINEXEFLAG=/target:winexe
        CSCFLAGS='/d:MONO /warn:4 /d:TRACE'
        CSCFLAGS_DEBUG="/debug+ /d:DEBUG"
        CSCFLAGS_OPTIMIZE="/optimize+"
        MONO=mono
        MONO_DEBUG='mono --debug'
        MONO_PATH=
        #SYSTEM_XML='System.Xml.dll'
    ;;
    #
    # .NET-specific configuration
    #
    csc)
        CSC_EXEFLAG=/target:exe
        CSC_LIBFLAG=/target:library
        CSC_WINEXEFLAG=/target:winexe
        CSCFLAGS='/d:DOTNET /warn:4 /d:TRACE /nologo'
        CSCFLAGS_DEBUG="/debug+ /d:DEBUG"
        CSCFLAGS_OPTIMIZE="/optimize+"
        MONO=
        MONO_DEBUG=
        MONO_PATH=
        #SYSTEM_XML='System.XML.dll'
    ;;
esac
AC_SUBST(CSC)
AC_SUBST(CSC_EXEFLAG)
AC_SUBST(CSC_LIBFLAG)
AC_SUBST(CSC_WINEXEFLAG)
AC_SUBST(CSCFLAGS)
AC_SUBST(MONO)
AC_SUBST(MONODOCER)
AC_SUBST(GACUTIL)
AC_SUBST(MONO_PATH)
AC_SUBST(SYSTEM_XML)

SRCDIR='$(top_srcdir)/src'

AC_SUBST(SRCDIR)

EMPTY=
SPACE='$(EMPTY) $(EMPTY)'

AC_SUBST(EMPTY)
AC_SUBST(SPACE)

COMMON_CLEAN_FILES='*.dbg *.exe *.dll *.pdb */*.pdb *.doc.xml */*.doc.xml *.test.xml */*.test.xml'
#COMMON_DISTCLEAN_FILES='*.suo */*.suo *.csproj.user */*.csproj.user bin obj */bin */obj'
COMMON_DISTCLEAN_FILES='*.suo */*.suo *.csproj.user */*.csproj.user  obj  */obj'
COMMON_MAINTAINER_CLEAN_FILES='Makefile.in'
AC_SUBST(COMMON_CLEAN_FILES)
AC_SUBST(COMMON_DISTCLEAN_FILES)
AC_SUBST(COMMON_MAINTAINER_CLEAN_FILES)


#
# Set platform-specific variables
#
case $host_os in
    #
    # MAC OS X configuration
    #
    darwin*)
        #
        # Set variables
        #
        CSCFLAGS="/d:DARWIN $CSCFLAGS"
        EMPTY=
        EXE_EXT=''
        ICON_EXT='.ico'
        ICON_FLAG='/resource:'
        INSTALL_EXE_OPTS='--mode=644'
        OBJ_EXT='.o'
        SEP='/'
        SHARED_LIB_EXT='.dylib'
        SHARED_LIB_FLAG='-shared'
        SYSTEM_XML='System.Xml.dll'
    ;;
    #
    # Linux-specific configuration
    #
    linux*)
        #
        # Set variables
        #
        CSCFLAGS="/d:LINUX $CSCFLAGS"
        EMPTY=
        EXE_EXT=''
        ICON_EXT='.ico'
        ICON_FLAG='/resource:'
        INSTALL_EXE_OPTS='--mode=644'
        OBJ_EXT='.o'
        SEP='/'
        SHARED_LIB_EXT='.so'
        SHARED_LIB_FLAG='-shared'
        SYSTEM_XML='System.Xml.dll'
    ;;
    #
    # Windows-specific configuration
    #
    cygwin*)
        #
        # Check for valid compilers
        #
        AC_CHECK_PROG(CC, cl, cl)
        test -z "$CC" && AC_MSG_ERROR([no acceptable C compiler found in \$PATH])
        AC_CHECK_PROG(CXX, cl, cl)
        test -z "$CXX" && AC_MSG_ERROR([no acceptable C++ compiler found in \$PATH])
        AC_CHECK_PROG(LD, link, link)
        test -z "$LD" && AC_MSG_ERROR([no acceptable linker found in \$PATH])
        #
        # Set variables
        #
        CC='cl -c'
        CXX='cl -c'
        CDEF='-D'
        CFLAGS="-nologo -W3 -DWIN32 -D_WINDOWS -DWINDOWS -DPACKAGE=\$(PACKAGE) -DVERSION=\$(VERSION)";
        CFLAGS_DEBUG="-MDd -Od -Zi -RTC1 -DDEBUG -D_DEBUG"
        CFLAGS_OPTIMIZE="-MD -O2 -DNDEBUG"
        CINC='-I'
        COUT='-Fo'
        CSCFLAGS="/d:WINDOWS $CSCFLAGS"
        CXXFLAGS="-nologo -GX -W3 -DWIN32 -D_WINDOWS -DWINDOWS -DPACKAGE=\$(PACKAGE) -DVERSION=\$(VERSION)";
        CXXFLAGS_DEBUG="-MDd -Od -Zi -RTC1 -DDEBUG -D_DEBUG"
        CXXFLAGS_OPTIMIZE="-MD -O2 -DNDEBUG"
        DEF='-def:'
        EMPTY=
        EXE_EXT='.exe'
        ICON_EXT='.ico'
        ICON_FLAG='/win32icon:'
        INSTALL_EXE_OPTS=''
        LDFLAGS='-nologo -machine:X86'
        LDFLAGS_DEBUG="-DEBUG"
        LDINC='-libpath:'
        LDOUT='-out:'
        LIB_EXT='.lib'
        LIB_PRE=''
        LIBFLAG=''
        LIBS='kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib rpcrt4.lib ws2_32.lib imagehlp.lib'
        OBJ_EXT='.obj'
        RC='rc'
        RC_FLAGS='-r'
        REPORT_DIR='$(shell cygpath --windows $(DESTDIR)$(bindir) | sed ''s,\\\\,/,g'')'
        REPORT_EXE='$(top_srcdir)/tools/Report/Report.exe'
        RES_EXT='.res'
        SEP='$(EMPTY)\\$(EMPTY)'
        SHARED_LIB_EXT='.dll'
        SHARED_LIB_FLAG='-dll'
        STORELIB="sqlite.dll"
        STORELIB_PATH="../../external/sqlite/w32"
        SYSTEM_XML='System.XML.dll'
        TLBX='tlbexp'
        TYPE_LIB_EXT='.tlb'
        bindir="${exec_prefix}"
        sbindir="${exec_prefix}"
        libexecdir="${exec_prefix}"
        libdir="${exec_prefix}"
    ;;
esac
AC_SUBST(CDEF)
AC_SUBST(CINC)
AC_SUBST(COUT)
AC_SUBST(CXX)
AC_SUBST(CXXFLAGS)
AC_SUBST(DEF)
AC_SUBST(DOCDIR)
AC_SUBST(ICON_EXT)
AC_SUBST(ICON_FLAG)
AC_SUBST(INSTALL_EXE_OPTS)
AC_SUBST(LDFLAGS)
AC_SUBST(LDINC)
AC_SUBST(LDOUT)
AC_SUBST(LIBS)
AC_SUBST(NUNIT)
AC_SUBST(NUNIT_FLAGS)
AC_SUBST(NUNIT_LIBPATH)
AC_SUBST(OBJ_EXT)
AC_SUBST(RC)
AC_SUBST(RCFLAGS)
AC_SUBST(REPORT_DIR)
AC_SUBST(REPORT_EXE)
AC_SUBST(RES_EXT)
AC_SUBST(SEP)
AC_SUBST(SHARED_LIB_FLAG)
AC_SUBST(SYSTEM_XML)
AC_SUBST(TLBX)


#
# Run standard macros
#
#AM_PROG_CC_STDC
#AC_PROG_INSTALL
#AC_HEADER_STDC
#AM_PROG_LIBTOOL

#
# Handle --enable-debug
#
AC_ARG_ENABLE(debug, [
  --enable-debug          configure the Makefiles to build in DEBUG mode],
    [case "${enableval}" in
        yes) enable_debug=true ;;
        no)  enable_debug=false ;;
        *) AC_MSG_ERROR(bad value ${enableval} for --enable-debug) ;;
    esac],[enable_debug=false])
AM_CONDITIONAL(DEBUG, test x$enable_debug = xtrue)
if test "$enable_debug" = "true"
then
  # Build debug version.
  CFLAGS="$CFLAGS_DEBUG $CFLAGS"
  CSCFLAGS="$CSCFLAGS_DEBUG $CSCFLAGS"
  CXXFLAGS="$CXXFLAGS_DEBUG $CXXFLAGS"
  DEVENV_CONFIGURATION=Debug
  MONO=$MONO_DEBUG
  NUNIT_FLAGS="$NUNITFLAGS_DEBUG $NUNIT_FLAGS"
else
  # Build optimized version.
  CFLAGS="$CFLAGS_OPTIMIZE $CFLAGS"
  CSCFLAGS="$CSCFLAGS_OPTIMIZE $CSCFLAGS"
  CXXFLAGS="$CXXFLAGS_OPTIMIZE $CXXFLAGS"
  DEVENV_CONFIGURATION=Release
  NUNIT_FLAGS="$NUNITFLAGS_OPTIMIZE $NUNIT_FLAGS"
fi
AC_SUBST(DEVENV_CONFIGURATION)

#
# Configure PKG_CONFIG
#
AC_PATH_PROG(PKG_CONFIG, pkg-config, no)
if test "x$PKG_CONFIG" = "xno"; then
    AC_MSG_ERROR([You need to install pkg-config])
fi

#
# Configure files
#
#src/SimpleService/Makefile
#src/SimpleClient/Makefile
AC_OUTPUT([
Makefile
src/Makefile
doc/Makefile
doc/MonoDoc/Makefile
])


