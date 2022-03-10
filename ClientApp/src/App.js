import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Boats } from './components/Boat/Boats';
import { BoatsList } from './components/Boat/BoatsList';
import { BoatAdd } from './components/Boat/BoatAdd';

import './custom.css'
import {Crew} from "./components/Crew/Crew";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/boats' component={Boats} />
        <Route exact path='/crew'  render={props => <Crew boat = {props.location.state}/>}/>
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}
