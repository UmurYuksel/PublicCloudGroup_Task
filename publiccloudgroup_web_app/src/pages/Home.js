import React from 'react'
import Iframe from 'react-iframe';

///Lets make the app little bit publiccloudgroupish :)
function Home () {
    return (
        <Iframe url="https://publiccloudgroup.com/"
            width="100%"
            height="100%"
            styles={{ height: '100%', position: 'absolute', left: '0px', width: '100%', overflow: 'hidden'}} />
    )
}

export default Home;