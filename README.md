# PTCG_Tracker

PTCG Tracker is a database tool that helps you track and sort your existing Pokemon Card Collection with enough flexibility to customize to your liking. No more digging through boxes and binders of cards. Your collection is only one button press away.

## Download From GitHub

Visit this URL to view/download [Project](https://github.com/jacobschilders/PTCG_Tracker).

```bash
https://github.com/jacobschilders/PTCG_Tracker
```

Visit this URL to view online on [Azure](https://ptcgtracker.azurewebsites.net/).

```bash
https://ptcgtracker.azurewebsites.net/
```


## Usage

```python
C# 
HTML 5
CSS 3
Bootstrap
Asure
GitHub

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Utilizing
Begin by adding your base Weaknesses & Resistances. You will need these IDs when adding Cards to the database. 
As you come across cards that have and Ability, you will need to add the ability to the database before you add the Card. 
The ability ID is needed to create a card. If the card does not have an ability use ID 3.

Once you have created as many cards as you would like you can begin creating some custom Collections to store them in.
Say, for example, you wanted to track all of your different Snorlax cards you own. You can create a Snorlax Collection and add all of your cards to that collection.
There are 29 different Snorlax cards in existance currently so you would want to make your CardsUntilComplete property  int 29.

## Future Updates

1. A way to filter the Cards by several different Parameters(Set, Series, SuperType, etc.).
   [A Search Bar on the Home Page would be ideal.]

2. Exception Handling - Improve the overall implimentation of the exceptions.

3. More user friendly page routing. 

4. Preset Collection Templates.
   i.e. -Standard Deck List -Expanded Deck List -Existing Sets & Expansions
   
5. Artist Biographies

6. An Index on the home page that shows how to search and impliment the CardId function.

7. The ability to add multiple of the same card to a collection. Helpful when creating a deck list.
