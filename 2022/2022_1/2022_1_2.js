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

var elves = input.split('\n\n');
var calorieCounts = [];
elves.forEach(elf => {
	var foods = elf.split('\n');
	var sum = foods.reduce(function (x, y) {
        return parseInt(x) + parseInt(y);
    }, 0);
    calorieCounts.push(sum);
});

var sorted = calorieCounts.sort(function(a,b){ 
  return a - b;
});

var one = sorted[sorted.length - 1];
var two = sorted[sorted.length - 2]
var three = sorted[sorted.length - 3]
	
console.log(one + two + three)