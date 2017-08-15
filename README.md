# Botom

The code for the bot-om I used for the Eeveelutions (and later "the Den") discord page.

## Setting up on Windows

- Just use the Visual Studio project to resolve dependencies and compile the code.
- Make sure you add your token.txt file to the project directory containing your discord token.

## Setting up on Linux (assuming Debian distro)

- Ensure you have `make` installed.
- Install Mono 2.4 with `sudo make install-mono`
- Install `nuget` with `sudo make install-nuget`
- Install the dependencies with `make install-packages`
- Build the code with `make all` or `make`

Alternatively, this script was tested and used successfully for Raspbian Jessie on the
Raspberry Pi 3:

```bash
sudo apt-key adv --keyserver pgp.mit.edu --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
sudo echo "deb http://download.mono-project.com/repo/debian wheezy main" > /etc/apt/sources.list.d/mono-xamarin.list)
sudo apt-get update
sudo apt-get install mono-devel mono-runtime -y
sudo wget -O /usr/bin/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -O /usr/bin/nuget.exe
certmgr -ssl https://go.microsoft.com
certmgr -ssl https://nugetgallery.blob.core.windows.net
certmgr -ssl https://nuget.org
nuget.exe install
nuget.exe restore
mkdir -p ./bin/mono
for asm in `find ~/.nuget/packages -wholename '*net45/*.dll'`; do cp $asm packages/$(basename $asm) -v; cp $asm bin/mono/$(basename $asm) -v; done
cp -a images bin/mono/images -v
cp token.txt bin/mono/token.txt -v
csc $(find -name '*.cs') /r:$(for f in `find -name '*.dll'`; do printf "$f;"; done) /out:bin/mono/botom.exe
```

...however, it seems these build tools are so complicated, and poorly documented, I cannot guarantee that this is a
reproducible result. It would probably be easier to just compile for Mono using Windows or make a new Mono project
and cross your fingers.

- Blah, blah, token.txt, blah blah.
