var input = `1000
2000
3000

4000

5000
6000

7000
8000
9000

10000`;

var elfs = input.split('\n\n');
var calorieCounts = [];
elfs.forEach(elf => {
	var foods = elf.split('\n');
	var sum = foods.reduce(function (x, y) {
        return parseInt(x) + parseInt(y);
    }, 0);
    calorieCounts.push(sum);
});

var max = Math.max(...calorieCounts)

console.log('result', max)