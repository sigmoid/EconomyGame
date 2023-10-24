import { useEffect } from 'react';
import AgentsView from './AgentsView';
import ResourcesView from './ResourcesView';
import AgentSchematicsView from './AgentSchematicsView';
import '../App.css';

const SceneSetup = () => {

    useEffect(() => {

    }, []);

    return (
        <div className="container-fluid h-100">
            <div className="row h-100">
                <div className="col bg-dark-cream h-100 overflow-auto">
                    <ResourcesView></ResourcesView>
                </div>
                <div className="col-md-8 bg-cream">
                    <AgentsView></AgentsView>
                </div>
                <div className="col bg-dark-cream h-100 overflow-auto">
                    <AgentSchematicsView></AgentSchematicsView>
                </div>
            </div>
        </div>
    );
}

export default SceneSetup;