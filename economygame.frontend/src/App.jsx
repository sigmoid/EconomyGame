import { useState,useEffect} from 'react';
import axios from 'axios';

const App = () => {

    const [agents, setAgents] = useState();

    useEffect(() => {
        axios.get('/api/EconomySim/getAgents')
            .then(resp => resp.text())
            .then(res => console.log(res));
    }, []);

    return (
        <>
        <h1>hello, world</h1>
        </>
    );
}

export default App;