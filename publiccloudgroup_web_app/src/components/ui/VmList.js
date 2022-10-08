import React from 'react';
import VmCard from './VmCard';

const VmList = (props) => {

  const listData = props.listData.length >0 ? props.listData : null ;
    
  return (
    <div>
      { (listData && listData.length>0) ? listData.map((item) => {return <VmCard key={item.lastStartTimestamp} singleItem={item} />} ) : null}
    </div>
  )
}

export default VmList;