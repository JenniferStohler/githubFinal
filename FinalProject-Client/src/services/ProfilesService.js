<template>
  <div class="about text-center" v-if="state.activeProfile">
    <div class="col-12">
      <div class="d-flex">
        <img class="rounded-circle" :src="state.activeProfile.picture" alt="Profile Image">
        <div class="d-flex flex-column justify-content-centerr">
          <h4 class="text-dark">
            {{ state.activeProfile.name }}
          </h4>
        </div>
      </div>
    </div>
  </div>
</template>