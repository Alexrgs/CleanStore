import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import ProductsList from "./components/ProductsList";
import './custom.css'




export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <AuthorizeRoute exact path='/' component={ProductsList} />
            <AuthorizeRoute exact path='/home' component={Home} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
    );
  }
}
