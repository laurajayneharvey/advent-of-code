var input = `30373
25512
65332
33549
35390`;
var lines = input.trim().split("\n");

var matrix = lines.map(line => [...line]);

var [row] = matrix;
var transposed = row.map((value, column) => matrix.map(row => row[column]));

var highestScenicScore = 0;
for (var i = 0; i < matrix.length; i++) {
    var currentRow = matrix[i];
    for (var j = 0; j < transposed.length; j++) {
        var currentColumn = transposed[j];
        var currentValue = matrix[i][j];
        var scenicScore = 0;

        var upScore = 0;
        var up = currentColumn.slice(0, i);
        for (var k = up.length - 1; k >= 0; k--) {
          if (up[k] >= currentValue) {
            upScore++;
            break;
          }
          
          upScore++;
        }

        var leftScore = 0;
        var left = currentRow.slice(0, j);
        for (var k = left.length - 1; k >= 0; k--) {
          if (left[k] >= currentValue) {
            leftScore++;
            break;
          }
          
          leftScore++;
        }
      
        var rightScore = 0;
        var right = currentRow.slice(j + 1, transposed.length);
        for (var k = 0; k < right.length; k++) {
          if (parseInt(right[k]) >= parseInt(currentValue)) {
            rightScore++;
            break;
          }
          
          rightScore++;
        }
        
        var downScore = 0;
        var down = currentColumn.slice(i + 1, matrix.length);
        for (var k = 0; k < down.length; k++) {
          if (down[k] >= currentValue) {
            downScore++;
            break;
          }
          
          downScore++;
        }

        var scenicScore = upScore * downScore * leftScore * rightScore;
        if (scenicScore > highestScenicScore) {
          highestScenicScore = scenicScore;
        }       
    }
}

console.log(highestScenicScore);