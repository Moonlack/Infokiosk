let cards = document.getElementsByClassName('item-card');
let maxHeight = Math.max.apply(Math,
    Array.prototype.map.call(cards,
        x => {
            return x.offsetHeight;
        }));

Array.prototype.forEach.call(cards,
    x => {
        x.style.height = maxHeight + 'px';
    }); 