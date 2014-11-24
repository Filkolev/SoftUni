function solve(args) {
    var result = {};

    for (var i in args) {
        var data = args[i].split(/\s+/g);
        var name = data[0];
        var extension = data[1];
        var memory = parseFloat(data[2]);

        if (!result[extension]) {
            result[extension] = {
                files: [],
                memory: 0
            }
        }

        if (result[extension].files.indexOf(name) == -1) {
            result[extension].files.push(name);
        }

        result[extension].memory += memory;
    }

    for (var j in result) {
        result[j].files.sort();
        result[j].memory = result[j].memory.toFixed(2);
    }

    var sortedKeys = Object.keys(result).sort();
    var toPrint = {};

    for (var k in sortedKeys) {
        toPrint[sortedKeys[k]] = result[sortedKeys[k]];
    }

    console.log(JSON.stringify(toPrint));

}

//solve([
//'sentinel .exe 15MB',
//'zoomIt .msi 3MB',
//'skype .exe 45MB',
//'trojanStopper .bat 23MB',
//'kindleInstaller .exe 120MB',
//'setup .msi 33.4MB',
//'winBlock .bat 1MB'
//]);

//solve([
//'eclipse .tar.gz 198.00MB',
//'uTorrent .gyp 33.02MB',
//'nodeJS .gyp 14MB',
//'nakov-naked .jpeg 3MB',
//'gnuGPL .pdf 5.6MB',
//'skype .tar.gz 66MB',
//'selfie .jpeg 7.24MB',
//'myFiles .tar.gz 783MB'
//]);