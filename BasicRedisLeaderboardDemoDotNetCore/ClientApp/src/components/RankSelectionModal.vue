<template>
  <v-dialog
    v-model="dialog"
    transition="dialog-bottom-transition"
    max-width="400px"
  >
    <template v-slot:activator="{ on, attrs }">
      <slot name="activator" v-bind="{ on, attrs }" />
    </template>
    <v-card>
      <v-card-title>
        <v-spacer />

        <v-icon
          aria-label="Close"
          @click="close"
        >
          mdi-close
        </v-icon>
      </v-card-title>
      <v-card-text>
        <div class="headline text-center mb-4">
          Select the menus below to update the rank of the companies
        </div>
        <v-select
          :items="companies"
          item-text="company"
          item-value="symbol"
          v-model="internalValue.symbol"
          placeholder="Select a company"
          dense
          outlined
        />
        <v-select
          :items="RANK_OP"
          v-model="internalValue.op"
          placeholder="Add or Subtract"
          dense 
          outlined
        />
        <v-select
          :items="AMOUNT_LIST"
          v-model="internalValue.amount"
          placeholder="Select Amount"
          dense
          outlined
        />
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn
          class="mb-4"
          color="primary"
          @click="onUpdateRank"
          :disabled="!isValid"
        >
          Update
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>

const TRILLION = 1000 * 1000 * 1000 * 1000;
const BILLION = 1000 * 1000 * 1000;
// const MILLION = 1000 * 1000;

export default {
  name: 'RankSelectionModal',
  components: {
  },

  props: {
    value: {
      type: Object,
    },
    companies: {
      type: Array,
    },
  },

  data () {
    return {
      dialog: false,
      RANK_OP: [
        { text: 'Add', value: 'add' },
        { text: 'Subtract', value: 'subtract' },
      ],
      AMOUNT_LIST: [
        { text: '10 Billions', value: BILLION * 10 },
        { text: '100 Billions', value: BILLION * 100 },
        { text: '1 Trillion', value: TRILLION },
        { text: '2 Trillion', value: TRILLION * 2 },
      ],
    }
  },

  watch: {
  },

  computed: {
    isValid () {
      return !!this.internalValue.symbol && !!this.internalValue.op && !!this.internalValue.amount
    },
    internalValue: {
      get () {
        return this.value
      },
      set (val) {
        this.$emit('input', val)
      },
    },
  },

  methods: {
    close () {
      this.dialog = false
    },
    onUpdateRank () {
      this.$emit('onUpdateRank')
      this.close()
    },
  },

  async mounted () {
  }
}
</script>

<style type="sass">
</style>