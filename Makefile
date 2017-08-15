all: rebuild

token.txt:
	$(error Please make a file called token.txt and place your discord token in it first.)

install-mono:
	apt-key adv --keyserver pgp.mit.edu --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
	$(shell echo "deb http://download.mono-project.com/repo/debian wheezy main" > /etc/apt/sources.list.d/mono-xamarin.list)
	apt-get update
	apt-get install mono-devel mono-runtime

install-nuget:
	wget -O /usr/bin/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe

install-packages:
	$(info I am going to update the SSL certificates so nuget will work. Just confirm these please.)
	certmgr -ssl https://go.microsoft.com
	certmgr -ssl https://nugetgallery.blob.core.windows.net
	certmgr -ssl https://nuget.org
	nuget.exe install

install-all: install-mono install-nuget install-packages

build: packages
	mkdir -p ./bin/mono
	for asm in `find ~/.nuget/packages/ -wholename '*net45/*.dll'`; do cp -a $$asm packages/$$(basename $$asm); cp $$asm bin/mono/$$(basename $$asm) -v; done
	cp -a images ./bin/mono/images -v
	cp token.txt ./bin/mono/token.txt -v
	csc $$(find -name '*.cs') /r:$$(for f in `find -name '*.dll'`; do printf "$$f;"; done) /out:bin/mono/botom.exe
	cp run.sh bin/mono/run.sh
	chmod 777 bin/mono/run.sh
	chmod 777 bin/mono/botom.exe

packages:
	nuget.exe restore
	mkdir -p packages

clean:
	$(RM) bin obj packages -Rvf

rebuild: clean token.txt build

.PHONY: install-mono install-nuget install-packages install-all build clean rebuild
