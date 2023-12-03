var getSurrounding = (rows, cols) => {
  var surrounding = [];
  // row above
  if (i - 1 >= 0) {
    var north = rows[i-1].split('');
    if (j - 1 >= 0) {
      var NW = north[j-1];
      if (NW === '*') {
        surrounding.push({"rowIndex": i-1, "colIndex": j-1});
      }
    }
    var N = north[j];
    if (N === '*') {
      surrounding.push({"rowIndex": i-1, "colIndex": j});
    }
    if (j + 1 < cols.length) {
      var NE = north[j+1];
      if (NE === '*') {
        surrounding.push({"rowIndex": i-1, "colIndex": j+1});
      }
    }
  }
  // same row
  if (j - 1 >= 0) {
    var W = cols[j-1];
    if (W === '*') {
      surrounding.push({"rowIndex": i, "colIndex": j-1});
    }
  }
  if (j + 1 < cols.length) {
    var E = cols[j+1];
    if (E === '*') {
      surrounding.push({"rowIndex": i, "colIndex": j+1});
    }
  }
  // row below
  if (i + 1 < rows.length) {
    var south = rows[i+1].split('');
    if (j - 1 >= 0) {
      var SW = south[j-1];
      if (SW === '*') {
        surrounding.push({"rowIndex": i+1, "colIndex": j-1});
      }
    }
    var S = south[j];
    if (S === '*') {
      surrounding.push({"rowIndex": i+1, "colIndex": j});
    }
    if (j + 1 < cols.length) {
      var SE = south[j+1];
      if (SE === '*') {
        surrounding.push({"rowIndex": i+1, "colIndex": j+1});
      }
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

var possibleGearsOverall = [];
var rows = input.split('\n');
for (i = 0; i < rows.length; i++) {
  var row = rows[i];
  var cols = row.split('');
  for (j = 0; j < cols.length; j++) {
    var col = cols[j];
    if (!isNaN(col)) {
      var possibleGearsHere = getSurrounding(rows, cols);
      if (possibleGearsHere.length) {
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
        
        possibleGearsHere.forEach(x => x.partNumber = partNumber);
        possibleGearsOverall.push(...possibleGearsHere);
      }
    }
  }
}

const possibleGears = possibleGearsOverall.reduce((group, possibleGear) => {
  const { rowIndex, colIndex, partNumber } = possibleGear;
  
  var existingGearRatio = group[`${rowIndex}-${colIndex}`]?.gearRatio ?? 1;
  var newGearRatio = existingGearRatio *= parseInt(partNumber);
  
  var existingCount = group[`${rowIndex}-${colIndex}`]?.count ?? 0;
  existingCount++;
  
  group[`${rowIndex}-${colIndex}`] = {"gearRatio": newGearRatio, "count": existingCount};
  return group;
}, {});

const gearRatioSum = Object.keys(possibleGears)
  .filter((key) => possibleGears[key].count === 2)
  .map((key) => possibleGears[key].gearRatio)
  .reduce((sum, current) => sum + current, 0);
  
console.log(gearRatioSum);