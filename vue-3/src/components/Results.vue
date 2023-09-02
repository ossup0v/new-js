<template>
    <p>Your reaction time {{ score }} ms!</p>
    <div class="rank">
        <div v-if="score < 250">Ninja fingers!</div>
        <div v-else-if="score < 600">Rapid reaction!</div>
        <div v-else>Too slow..</div>
    </div>
</template>

<script>
export default {
    props: ['score']
}


</script>

<style>
    .rank {
        font-size: 1.4rem;
        color: #0faf87;
        font-weight: bold;
    }
</style>