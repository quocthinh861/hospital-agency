import styled from 'styled-components'
import {BrowserRouter as Router, Route, Redirect, Switch} from 'react-router-dom'
import {useState} from 'react'
import {useSelector} from 'react-redux'
import axios from 'axios'
import Login from "./pages/Login"
import Home from "./pages/Home"


function ProtectedRoute({user, children, ...props}){
  return  <Route 
  render = {() => {
    if(!user){
      return <Redirect to='/login'></Redirect>
    }
    else {
      return children;
    }
  }}
  />
}

function Register(){

  return (
    <h1>This is register page</h1>
  )
}

function App() {
  const user = useSelector(state => state.user);

  return (
    <Router>
      <Switch>
        <Route path='/login' exact>
          <Login />
        </Route>
        <Route path='/register' exact>
          <Register />
        </Route>
        <ProtectedRoute path='/' user exact>
          <Home />
        </ProtectedRoute>
      </Switch>
    </Router>
  );
}

export default App;
