import { browser, element, by } from 'protractor';
import { Locator } from 'protractor/built/locators';

export class ClientPage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {
    return element(<Locator>by.css('app-root h1')).getText();
  }
}
