import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import PhoneBookList  from './components/PhoneBookList';
import PhoneBookAdd from './components/PhoneBookAdd';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={PhoneBookList} />
        <Route path='/add-entry' component={PhoneBookAdd} />
      </Layout>
    );
  }
}
