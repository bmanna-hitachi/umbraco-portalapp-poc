const openMobileMenuButton = document.getElementById("openMobileMenuButton");
const closeMobileMenuButton = document.getElementById("closeMobileMenuButton");
const sidebar = document.getElementById("sidebar");
const toggleSidebar = () => sidebar.classList.toggle("-translate-x-full");
openMobileMenuButton.addEventListener("click", toggleSidebar);
closeMobileMenuButton.addEventListener("click", toggleSidebar);

// HIDE / SHOW menu/submenu using JS
// Originally, this was done usin CSS pseudoclasses
// However, CSS pseudoclassses don't work properly with nested focussable elements
// i.e, <button><a></a></button> such situations
// so implementing the same functionality using vanilla JS

// all submenus
const submenuCgiServices = document.getElementById("submenuCgiServices");
const submenuSrfActivities = document.getElementById("submenuSrfActivities");
const submenuHistory = document.getElementById("submenuHistory");
const submenuUser = document.getElementById("submenuUser");
// all menus
const menuCgiServices = document.getElementById("menuCgiServices");
const menuSrfActivities = document.getElementById("menuSrfActivities");
const menuHistory = document.getElementById("menuHistory");
const menuUser = document.getElementById("menuUser");
// function to toggle the submenu
const toggleHidden = (element) => element.classList.toggle("hidden");

// implement the toggle behaviour
if (menuCgiServices) {
  menuCgiServices.addEventListener("click", () => {
    toggleHidden(submenuCgiServices);
  });
}
if (menuSrfActivities) {
  menuSrfActivities.addEventListener("click", () => {
    toggleHidden(submenuSrfActivities);
  });
}
if (menuHistory) {
  menuHistory.addEventListener("click", () => {
    toggleHidden(submenuHistory);
  });
}
if (menuUser) {
  menuUser.addEventListener("click", () => {
    toggleHidden(submenuUser);
  });
}

// capture all clicks on the document
// check if the event is on any of the menu or submenu / sidebar
// if not, hide all relevant submenus / sidebars
// seems like an inefficient method, but works great!
document.addEventListener("click", (event) => {
  if (
    menuCgiServices &&
    !submenuCgiServices.contains(event.target) &&
    !menuCgiServices.contains(event.target)
  ) {
    submenuCgiServices.classList.add("hidden");
  }
  if (
    menuSrfActivities &&
    !submenuSrfActivities.contains(event.target) &&
    !menuSrfActivities.contains(event.target)
  ) {
    submenuSrfActivities.classList.add("hidden");
  }
  if (
    menuHistory &&
    !submenuHistory.contains(event.target) &&
    !menuHistory.contains(event.target)
  ) {
    submenuHistory.classList.add("hidden");
  }
  if (
    menuUser &&
    !submenuUser.contains(event.target) &&
    !menuUser.contains(event.target)
  ) {
    submenuUser.classList.add("hidden");
  }
  if (
    !sidebar.contains(event.target) &&
    !openMobileMenuButton.contains(event.target)
  ) {
    sidebar.classList.add("-translate-x-full");
  }
});
