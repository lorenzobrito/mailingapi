import React, { useState, useEffect } from "react";
import './App.css';
import Useradd from './UserAdd'
function App() {
  const [users, setUsers] = useState([]);
  const [lastname, setLastName] = useState('');
  const searchUser=(e)=> {
    e.preventDefault();
  Search();
}; 
const Search =() =>{
  var url ="";
  if(lastname)
  url=   `https://apimailtest.azurewebsites.net/api/Maillist/filter/${lastname}/Asc`
  else  url=  `https://apimailtest.azurewebsites.net/api/Maillist/filter/`
fetch(
 url
)
.then(async response => {
  
    const isJson = response.headers.get('content-type')?.includes('application/json');
    const data = isJson && await response.json();

    // check for error response
    if (!response.ok) {
        // get error message from body or default to response status
        const error = (data && data.message) || response.status;
        return Promise.reject(error);
    }

    setUsers(data);

})
  .catch(error => alert(error));
}
useEffect(() => {
  // Your code here
  Search();
}, []);
  return (
    <div className="App">
      <header>
       
      </header>
      <div>
        <Useradd/>
      </div>
      <div>
        <div>Search</div>
            <div>
            <div>          
            <div>
            <input type="text" value={lastname} text onChange={e => setLastName(e.target.value)} />
            </div>
        </div>
            <div>
            <button  onClick={(e)=>searchUser(e)} > Search </button>
                   </div>
            </div>
      </div>
      <div>
        <table>
        <tr>
    <th>name</th>
    <th>lastname</th>
    <th>email</th>
  </tr>
       {
         users.map((item, index) =>{
           console.log(item);
           return ( <tr key={index}> 
                <td>{item.name}</td>
                <td>{item.lastName}</td>
                <td>{item.email}</td>
              </tr> )

         } )
       }
       </table>
      </div>
    </div>
  );
}

export default App;
