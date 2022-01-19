import React, { useState, useEffect } from "react";
import logo from './logo.svg';
import './App.css';

function Useradd() {
    const [name, setName] = useState('');
    const [lastname, setLastName] = useState('');
    const [email, setEmail] = useState('');
  const addUser=(e)=> {
      e.preventDefault();
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name: name , 
                               lastName : lastname,
                            email :email
        
        }),
        crossDomain:false,
    };
    fetch(
      `https://localhost:7240/api/Maillist`,requestOptions
    )
    .then(async response => {
        console.log( response.headers.get('content-type'))
        const isJson = response.headers.get('content-type')?.includes('application/json');
        const data = isJson && await response.json();

        // check for error response
        if (!response.ok) {
            // get error message from body or default to response status
            const error = (data && data.message) || response.status;
            return Promise.reject(error);
        }

        
        alert(data.message);
        setName('');
        setLastName('');
        setEmail('')
    })
      .catch(error => alert(error));
  };
  return (
    <div>
        <div>
            <div>Name {name}</div>
            <div>
            <input type="text" value={name} text onChange={e => setName(e.target.value)} />
            </div>
        </div>
        <div>
            <div>Name {name}</div>
            <div>
            <input type="text" value={name} text onChange={e => setName(e.target.value)} />
            </div>
        </div>
        <div>
            <div>email {email}</div>
            <div>
            <input type="text" value={email} onChange={e => setEmail(e.target.value)} />
            </div>
        </div>
        <div>
            <button  onClick={(e)=>addUser(e)} >Add user </button>
        </div>
    </div>
  );

}

export default Useradd;
