var input = `R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20`;
var lines = input.trim().split("\n");

function doSomething(H, T) {
  var Hx = H[H.length - 1].x;
  var Hy = H[H.length - 1].y;
  var Tx = T[T.length - 1].x;
  var Ty = T[T.length - 1].y;

  if (Math.abs(Tx - Hx) <= 1 && Math.abs(Ty - Hy) <= 1) {
    T.push({x: Tx, y: Ty});
    return T;
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

  return T;
}

var H = [{x: 0, y: 0}];
var one = [{x: 0, y: 0}];
var two = [{x: 0, y: 0}];
var three = [{x: 0, y: 0}];
var four = [{x: 0, y: 0}];
var five = [{x: 0, y: 0}];
var six = [{x: 0, y: 0}];
var seven = [{x: 0, y: 0}];
var eight = [{x: 0, y: 0}];
var nine = [{x: 0, y: 0}];

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

    one = doSomething(H, one);
    two = doSomething(one, two);
    three = doSomething(two, three);
    four = doSomething(three, four);
    five = doSomething(four, five);
    six = doSomething(five, six);
    seven = doSomething(six, seven);
    eight = doSomething(seven, eight);
    nine = doSomething(eight, nine);
  }
})

var unique = [...new Set(nine.map(item => `xy${item.x}y=${item.y}`))];
console.log(unique.length)