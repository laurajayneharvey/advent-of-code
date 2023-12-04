var input = `Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11`;

var sum = 0;

var scratchCards = input.split("\n");
var map = {};
var currentCards = "";
scratchCards.forEach((scratchCard, index) => {
  var lists = scratchCard.split("|");
  var list1 = lists[0].split(":")[1].trim();
  var list2 = lists[1].trim();
  var winningNumbers = list1.split(" ");
  var numbersYouHave = list2.split(" ").filter(x => x != "");
  var intersection = winningNumbers.filter(value => numbersYouHave.includes(value));
  var matchCount = intersection.length;

  var current = index + 1;
  var cardsWonStart = current + 1;
  var cardsWonEnd = current + matchCount;
  var cardsWon = Array(cardsWonEnd - cardsWonStart + 1).fill().map((_, idx) => cardsWonStart + idx);

  map[current] = cardsWon.join('-');
  currentCards += `${current}-`;
});

var addTo = '';
var takeAway = currentCards;
var counts = {};
var withoutHyphens = currentCards.replace("-", "");
while (withoutHyphens.length > 0) {
  addTo = '';
  takeAway = currentCards;
  sum += [...currentCards].filter(char => char === '-').length;
  counts = currentCards.split("-").reduce((accumulator, currentValue) => { accumulator[currentValue] = accumulator[currentValue] ? accumulator[currentValue] + 1 : 1; return accumulator }, {}); 
  
  Object.keys(counts).forEach(key => {
    if (map[key]) {
       for (var i = 0; i < counts[key]; i++) {
        addTo += `${map[key]}-`;
      }
    }
  
    takeAway = takeAway.replaceAll(`${key}-`, "");
  });
  
  currentCards = addTo;
  withoutHyphens = currentCards.replaceAll("-", "");
}

console.log(sum);