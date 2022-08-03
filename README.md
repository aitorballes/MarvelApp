# MarvelApp

- This project consists of an application where Marvel movies and series are shown. 

- The application is divided in three main screens inside a TabbedPage. 

- In the first tab, called Home, we will see the latest comics and series with two different list layouts.

- To continue, in the second screen we have a search page with a small filter below to differentiate between "Comics" and "Series". Clicking on any item in any list in the application will navigate to the detail.

- The detail page shows more detailed information about the item and gives you the possibility to mark it as a favorite.

- Finally in the third tab we have the list of favorites.

# MVVM Architecture

- I have chosen to use Prsim, I find it a very complete and intuitive framework. I hadn't tried it for a while and I wanted to see how it had improved. 

- In my opinion, this framework makes your life easier. Just with the navigation service and the ViewModelLocator it's worth it.

# Embeded Database

- For the persistence in the application I have used LiteDb, which I find quite easy to use and fast to implement.

# Unit Testing

- As for the unit tests, I have tested both the viewmodels and the service layer using xUnit.