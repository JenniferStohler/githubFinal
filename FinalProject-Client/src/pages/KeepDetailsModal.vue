<template>
  <!-- Full screen modal -->
  <div class="modal-dialog modal-fullscreen-xxl-down">
    <Keep v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
  </div>
</template>
