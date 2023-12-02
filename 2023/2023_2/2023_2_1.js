var input = `Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green`;

var possibleIdSum = 0;
var games = input.split(/\r?\n/);

games.forEach(game => {
	var gameParts = game.split(": ");
  var id = gameParts[0].replace("Game ", "");
  var rounds = gameParts[1].split("; ");
  var impossible = false;
  
	var impossibleRound = rounds.some(round => {
  	var cubes = round.split(", ");
    
    var impossibleCube = cubes.some(cube => {
    	var cubeParts = cube.split(" ");
      var count = cubeParts[0];
			var colour = cubeParts[1];
      if (colour == "blue" && count > 14) {
				return true;
			}
      if (colour == "red" && count > 12) {
				return true;
			}
      if (colour == "green" && count > 13) {
				return true;
			}
      
      return false;
    });
    
    return impossibleCube;
  });
  
  if (!impossibleRound) {
  	possibleIdSum += parseInt(id);
  }
});

console.log(possibleIdSum);