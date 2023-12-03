var getSurrounding = (rows, cols) => {
	var surrounding = [];
	// row above
  if (i - 1 >= 0) {
    var north = rows[i-1].split('');
    if (j - 1 >= 0) {
      var NW = north[j-1];
      surrounding.push(NW);
    }
    var N = north[j];
    surrounding.push(N);
    if (j + 1 < cols.length) {
      var NE = north[j+1];
      surrounding.push(NE);
    }
  }
  // same row
  if (j - 1 >= 0) {
    var W = cols[j-1];
    surrounding.push(W);
  }
  if (j + 1 < cols.length) {
    var E = cols[j+1];
    surrounding.push(E);
  }
  // row below
  if (i + 1 < rows.length) {
    var south = rows[i+1].split('');
    if (j - 1 >= 0) {
      var SW = south[j-1];
      surrounding.push(SW);
    }
    var S = south[j];
    surrounding.push(S);
    if (j + 1 < cols.length) {
      var SE = south[j+1];
      surrounding.push(SE);
    }
  }
  return surrounding
}

var input = 
`467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..`;

var partNumberSum = 0;
var rows = input.split('\n');
for (i = 0; i < rows.length; i++) {
	var row = rows[i];
	var cols = row.split('');
  for (j = 0; j < cols.length; j++) {
  	var col = cols[j];
    if (!isNaN(col)) {
    	var surrounding = getSurrounding(rows, cols);
      var hasSymbol = surrounding.some(x => x !== '.' && isNaN(x));
      if (hasSymbol) {
      	var partNumber = col;
      
      	// find numbers before
        var k = j - 1;
        while (k >= 0 && !isNaN(cols[k])) {
        	partNumber = cols[k] + partNumber;
          k--;
        }
        // find numbers after
        var l = j + 1;
        while (l < cols.length && !isNaN(cols[l])) {
        	partNumber = partNumber + cols[l];
          l++;
          j = l;
        }  
        
        partNumberSum += parseInt(partNumber);
      }
    }
  }
}

console.log(partNumberSum);