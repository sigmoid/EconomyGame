import { useEffect, useState } from 'react';
import '../App.css';
import axios from '../../node_modules/axios/index';

const ResourcesView = () => {
    const [resources, setResources] = useState([]);

    useEffect(
        () => {
            getResourceTypes();
        },
        []);

    useEffect(() => { console.log(resources.length)},[resources])

    const getResourceTypes = () => {
        axios.get('/api/EconomySim/GetResourceTypes')
            .then(x => setResources(x.data));
    }

    const createNewResourceType = async (e) => {
        e.preventDefault();

        await axios.post('/api/EconomySim/InsertResourceType')
        getResourceTypes();
    }

    const setResourceTypeName = (e, id) => {
        setResources(resources.map(x => (x.resourceTypeId == id) ? { ...x, name: e.target.value } : x));
    }

    const deleteResourceType = async (e, id) => {
        e.preventDefault();

        const params = new URLSearchParams();
        params.append('resourceTypeId', id);
        await axios.post('/api/EconomySim/DeleteResourceType?' + params.toString())
        getResourceTypes();
    }

    return (
        <div>
        <h1>Resource Types</h1>
            {
                resources.length > 0 ?

                    resources.map((x) => {
                        return (
                            <div className="m-2 container" key={x.ResourceTypeId} >
                                <div className="row">
                                    <div className="col">
                                        <input type="text" className="form-control" value={x.Name} onChange={e => setResourceTypeName(e, x.resourceTypeId)}></input>
                                    </div>
                                    <div className="col-xs">
                                        <button onClick={e => deleteResourceType(e, x.resourceTypeId)} type="button" className="btn btn-danger">X</button>
                                    </div>
                                </div>
                            </div>
                        );
                    })
                    :
                    <div></div>
            }

            <button type="button" className="btn btn-success" onClick={ createNewResourceType}>Add New</button>
        </div >
    );
}

export default ResourcesView;