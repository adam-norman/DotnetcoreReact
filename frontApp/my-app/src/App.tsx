import axios from "axios";
import { useEffect, useState } from "react";
import { Header, Icon, List } from "semantic-ui-react";

function App(){
    const [activities,setActivites]= useState([]);
    useEffect(()=>{
        axios.get("https://localhost:44310/api/Activities").then((response:any)=>{
        console.log(response)    ;
        setActivites(response.data);

        })
    },[]);
    return (
        <div>
    <Header as='h2' icon  >
      <Icon name='users' circular />
      <Header.Content>Reactivities</Header.Content>
    </Header>
      
        <List>
            {activities.map((activity:any) => (
            <List.Item key={activity.id}>{activity.title}</List.Item>
            ))}
        </List>
        
 
</div>
    )
}

export default App;
