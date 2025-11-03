import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { Activity, useState } from "react";
import { useEffect} from "react";

function App() {

const [activities, setActivities] = useState<Activity[]>([]);

useEffect(() => {
axios.get<Activity[]>("http://localhost:5001/api/activities")
.then(response => setActivities(response.data))
.catch(error => console.error("Error fetching data:", error));
}, [])
  return (
    <>
      <Typography variant='h3'>
      Reactivities
      </Typography>
      <List>
        {activities.map((activity) => (
          <ListItem key = {activity.id}>
            <ListItemText>
              {activity.title}
            </ListItemText>

          </ListItem>
        )
        )
        }
      </List>
    </>
  )
}

export default App
