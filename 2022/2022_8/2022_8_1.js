var input = `30373
25512
65332
33549
35390`;
var lines = input.trim().split("\n");

var matrix = lines.map(line => [...line]);

var [row] = matrix;
var transposed = row.map((value, column) => matrix.map(row => row[column]));

var edge = 0;
var interior = 0;
for (var i = 0; i < matrix.length; i++) {
    var currentRow = matrix[i];
    for (var j = 0; j < transposed.length; j++) {
        var currentValue = matrix[i][j];
      
        if (i == 0 || i == matrix.length - 1 || j == 0 || j == transposed.length - 1) {
            edge++;
            continue;
        }

        var left = currentRow.slice(0, j);
        if (!left.find(tree => parseInt(tree) >= parseInt(currentValue))) {
          interior++;
          continue;
        }
        var right = currentRow.slice(j + 1, transposed.length);
        if (!right.find(tree => parseInt(tree) >= parseInt(currentValue))) {
          interior++;
          continue;
        }

        var currentColumn = transposed[j];
        var above = currentColumn.slice(0, i);
        if (!above.find(tree => parseInt(tree) >= parseInt(currentValue))) {
          interior++;
          continue;
        }
        var below = currentColumn.slice(i + 1, matrix.length);
        if (!below.find(tree => parseInt(tree) >= parseInt(currentValue))) {
          interior++;
          continue;
        }
    }
}

console.log(edge + interior);