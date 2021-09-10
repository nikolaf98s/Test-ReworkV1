
 function onload() {
    fetch('https://localhost:5001/Survey/report')
        .then(response => response.json())
        .then(json => loadBarChart(json))
}

function loadBarChart(json){
    console.log(json);
    avgScore = [];
    const labels = []
    
    i = 0;
    json.forEach(element => {
       avgScore[i] = element.averageRating;
       labels[i] = element.productName;
       i++;
    });                        
    const data = {
      labels: labels,
      datasets: [{
        label: '',
        backgroundColor: 'rgb(255, 99, 132)',
        borderColor: 'rgb(255, 99, 132)',
        data: avgScore,
      }]
    };
    const config = {
      type: 'bar',
      data: data,
      options: { responsive: true}
    };
    var myChart = new Chart(
    document.getElementById('BarChart'),
    config
    );
}
