var input = `R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2`;
var lines = input.trim().split("\n");

var H = [{x: 0, y: 0}];
var T = [{x: 0, y: 0}];
lines.forEach(line => {
  var parts = line.split(' ');
  var direction = parts[0];
  var step = parts[1];

  for (var i = 0; i < step; i++) {
    var Hx = H[H.length - 1].x;
    var Hy = H[H.length - 1].y;
    if (direction == 'R') {
      Hx++;
    } else if (direction == 'L') {
      Hx--;
    } else if (direction == 'U') {
      Hy++;
    } else if (direction == 'D') {
      Hy--;
    }

    H.push({x: Hx, y: Hy});

    Hx = H[H.length - 1].x;
    Hy = H[H.length - 1].y;
    var Tx = T[T.length - 1].x;
    var Ty = T[T.length - 1].y;

    if (Math.abs(Tx - Hx) <= 1 && Math.abs(Ty - Hy) <= 1) {
      T.push({x: Tx, y: Ty});
      continue;
    }

    if (Tx == Hx) {
      // do nothing
    } else if (Tx > Hx) {
      Tx--;
    } else {
      Tx++;
    }
    if (Ty == Hy) {
      // do nothing
    } else if (Ty > Hy) {
      Ty--;
    } else {
      Ty++;
    }
    T.push({x: Tx, y: Ty});
  }
})

var unique = [...new Set(T.map(item => `xy${item.x}y=${item.y}`))];
console.log(unique.length)