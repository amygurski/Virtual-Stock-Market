<template>
    <div id="footer-container">
        <footer id="footer-body">
            <p>&copy;2020 Team Tilde. All rights reserved.</p>
            <p>Site designed by Team Tilde</p>
        </footer>
    </div>
</template>
<script>
export default {
    name: 'footer-custom'
}
</script>
<style scoped>
#footer-container{
    display: flex;
    flex-direction: row;
    align-items: flex-end;
    flex-basis: auto;
    width: 100%;
    height: 90px;
    background-color: #282a2e;
    position: absolute;
    bottom: 0;
}
#footer-body{
    width: 100%;
    text-align: center;
    color: white;
}
</style>