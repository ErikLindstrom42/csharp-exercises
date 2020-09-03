function main() {
  // Put your code here
  const names = ["Nashville", "Hong Kong", "The back yard", "Earth",
    "London", "The mall", "Ryman Auditorium", "The Great Wall of China"]

  console.log("All Place Names")

  for (let name of names) {
    console.log(name)

  }
  console.log("")

  for (let name of names) {
    if (name.startsWith("The")) {
      console.log(name)
    }
  }


}

main();