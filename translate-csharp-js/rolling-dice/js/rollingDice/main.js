function main() {
  // Put your code here
  console.log("Let's roll some dice, baby!")
  console.log("---------------------------");

  // let die1, die2 = { value: "", string: "" }
  let die1 = { value: "", string: "" }
  let die2 = { value: "", string: "" }

  const roll = () => {
    let dieValue = Math.ceil(Math.random() * 6)



    return dieValue

  }
  const face = (value) => {
    switch (value) {
      case 1:
        dieString = "\u2680";
        break;
      case 2:
        dieString = "\u2681";
        break;
      case 3:
        dieString = "\u2682";
        break;
      case 4:
        dieString = "\u2683";
        break;
      case 5:
        dieString = "\u2684";
        break;
      case 6:
        dieString = "\u2685";
        break;
    }
    return dieString

  }

  for (let i = 0; i < 10; i++) {
    die1.value = roll();
    die2.value = roll();
    die1.string = face(die1.value)
    die2.string = face(die2.value)

    message = `${die1.string} + ${die2.string} == ${die1.value + die2.value}`;
    if (die1.value == die2.value) {
      message += " DOUBLES!";
    }

    console.log(message);
  }


}

main();